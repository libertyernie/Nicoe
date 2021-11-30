#include <malloc.h>
#include <cstring>

#include "CommonConfig.h"
#include "ByteOrderConversion.h"
#include "Enums.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::IO;

public ref class NintendontConfiguration {
private:
	NIN_CFG* ncfg;

	inline String^ ReadString(const char* source) {
		return gcnew String(source, 0, sizeof(source));
	}

	inline void WriteString(char* dest, String^ source) {
		memset(dest, 0, sizeof(dest));
		IntPtr str2 = Marshal::StringToHGlobalAnsi(source);
		strncpy(dest, (char*)(void*)str2, sizeof(dest));
		Marshal::FreeHGlobal(str2);
	}

	bool LoadNinCFG(String^ path)
	{
		bool ConfigLoaded = true;

		int64_t BytesRead;

		{
			FileStream inStream(path, FileMode::Open, FileAccess::Read);
			UnmanagedMemoryStream outStream((uint8_t*)ncfg, sizeof(NIN_CFG), sizeof(NIN_CFG), FileAccess::Write);
			inStream.CopyTo(% outStream);
			BytesRead = inStream.Position;
		}

		*ncfg = nincfg_ntoh(*ncfg);

		switch (ncfg->Version) {
		case 2:
			if (BytesRead != 540)
				ConfigLoaded = false;
			break;

		default:
			if (BytesRead != sizeof(NIN_CFG))
				ConfigLoaded = false;
			break;
		}

		if (ncfg->Magicbytes != 0x01070CF6)
			ConfigLoaded = false;

		UpdateNinCFG();

		if (ncfg->Version != NIN_CFG_VERSION)
			ConfigLoaded = false;

		if (ncfg->MaxPads > NIN_CFG_MAXPAD)
			ConfigLoaded = false;

		return ConfigLoaded;
	}

	void UpdateNinCFG()
	{
		if (ncfg->Version == 2)
		{	//251 blocks, used to be there
			ncfg->NetworkProfile = 0x2;
			ncfg->Version = 3;
		}
		if (ncfg->Version == 3)
		{	//new memcard setting space
			ncfg->MemCardBlocks = ncfg->NetworkProfile;
			ncfg->VideoScale = 0;
			ncfg->VideoOffset = 0;
			ncfg->Version = 4;
		}
		if (ncfg->Version == 4)
		{	//Option got changed so not confuse it
			ncfg->Config &= ~NIN_CFG_HID;
			ncfg->Version = 5;
		}
		if (ncfg->Version == 5)
		{	//New Video Mode option
			ncfg->VideoMode &= ~NIN_VID_PATCH_PAL50;
			ncfg->Version = 6;
		}
		if (ncfg->Version == 6)
		{	//New flag, disabled by default
			ncfg->Config &= ~NIN_CFG_ARCADE_MODE;
			ncfg->Version = 7;
		}
		if (ncfg->Version == 7)
		{	// Wiimote CC Rumble, disabled by default;
			// don't skip IPL by default.
			ncfg->Config &= ~NIN_CFG_CC_RUMBLE;
			ncfg->Config &= ~NIN_CFG_SKIP_IPL;
			ncfg->Version = 8;
		}
		if (ncfg->Version == 8)
		{	// BBA Emu disabled by default
			// BBA Config 0 by default
			ncfg->Config &= ~NIN_CFG_BBA_EMU;
			ncfg->NetworkProfile = 0;
			ncfg->Version = 9;
		}
		if (ncfg->Version == 9) {
			ncfg->WiiUGamepadSlot = 0;
			ncfg->Version = 10;
		}
	}
public:
	NintendontConfiguration() {
		ncfg = (NIN_CFG*)malloc(sizeof(NIN_CFG));
	}

	bool Equals(Object^ obj) override {
		if (obj == nullptr || this->GetType() != obj->GetType())
			return false;

		NintendontConfiguration^ x = dynamic_cast<NintendontConfiguration^>(obj);
		return memcmp(x->ncfg, ncfg, sizeof(NIN_CFG)) == 0;
	}

	property uint32_t Version {
		uint32_t get() {
			return ncfg->Version;
		}
	}

	property NinCFGFlags Config {
		NinCFGFlags get() {
			return (NinCFGFlags)ncfg->Config;
		}
		void set(NinCFGFlags value) {
			ncfg->Config = (uint32_t)value;
		}
	}

	property NinCFGVideoMode VideoMode {
		NinCFGVideoMode get() {
			return (NinCFGVideoMode)(ncfg->VideoMode & NIN_VID_MASK);
		}
		void set(NinCFGVideoMode value) {
			ncfg->VideoMode &= ~NIN_VID_MASK;
			ncfg->VideoMode |= (uint32_t)value & NIN_VID_MASK;
		}
	}

	property NinCFGForcedVideoMode ForcedVideoMode {
		NinCFGForcedVideoMode get() {
			return (NinCFGForcedVideoMode)(ncfg->VideoMode & NIN_VID_FORCE_MASK);
		}
		void set(NinCFGForcedVideoMode value) {
			ncfg->VideoMode &= ~NIN_VID_FORCE_MASK;
			ncfg->VideoMode |= (uint32_t)value & NIN_VID_FORCE_MASK;
		}
	}

	property bool ProgressiveScan {
		bool get() {
			return ncfg->VideoMode & NIN_VID_PROG;
		}
		void set(bool value) {
			ncfg->VideoMode &= ~NIN_VID_PROG;
			if (value) {
				ncfg->VideoMode |= NIN_VID_PROG;
			}
		}
	}

	property bool PatchPAL50 {
		bool get() {
			return ncfg->VideoMode & NIN_VID_PATCH_PAL50;
		}
		void set(bool value) {
			ncfg->VideoMode &= ~NIN_VID_PATCH_PAL50;
			if (value) {
				ncfg->VideoMode |= NIN_VID_PATCH_PAL50;
			}
		}
	}

	property NinCFGLanguage Language {
		NinCFGLanguage get() {
			return (NinCFGLanguage)ncfg->Language;
		}
		void set(NinCFGLanguage value) {
			ncfg->Language = (uint32_t)value;
		}
	}

	property String^ GamePath {
		String^ get() {
			return ReadString(ncfg->GamePath);
		}
		void set(String^ value) {
			WriteString(ncfg->GamePath, value);
		}
	}

	property String^ CheatPath {
		String^ get() {
			return ReadString(ncfg->CheatPath);
		}
		void set(String^ value) {
			WriteString(ncfg->CheatPath, value);
		}
	}

	property uint32_t MaxPads {
		uint32_t get() {
			return ncfg->MaxPads;
		}
		void set(uint32_t value) {
			ncfg->MaxPads = value;
		}
	}

	property String^ GameID {
		String^ get() {
			return ReadString(ncfg->GameID);
		}
		void set(String^ value) {
			WriteString(ncfg->GameID, value);
		}
	}

	property uint8_t MemCardBlocks {
		uint8_t get() {
			return ncfg->MemCardBlocks;
		}
		void set(uint8_t value) {
			ncfg->MemCardBlocks = value;
		}
	}

	property int8_t VideoScale {
		int8_t get() {
			return ncfg->VideoScale;
		}
		void set(int8_t value) {
			ncfg->VideoScale = value;
		}
	}

	property int8_t VideoOffset {
		int8_t get() {
			return ncfg->VideoOffset;
		}
		void set(int8_t value) {
			ncfg->VideoOffset = value;
		}
	}

	property uint8_t NetworkProfile {
		uint8_t get() {
			return ncfg->NetworkProfile;
		}
		void set(uint8_t value) {
			ncfg->NetworkProfile = value;
		}
	}

	property uint32_t WiiUGamepadSlot {
		uint32_t get() {
			return ncfg->WiiUGamepadSlot;
		}
		void set(uint32_t value) {
			ncfg->WiiUGamepadSlot = value;
		}
	}

	array<uint8_t>^ Export() {
		NIN_CFG toExport = nincfg_hton(*ncfg);

		array<uint8_t>^ arr = gcnew array<uint8_t>(sizeof(NIN_CFG));
		pin_ptr<uint8_t> pin = &arr[0];
		memcpy(pin, &toExport, sizeof(NIN_CFG));

		return arr;
	}

	void Reset() {
		memset(ncfg, 0, sizeof(NIN_CFG));

		ncfg->Magicbytes = 0x01070CF6;
		ncfg->Version = NIN_CFG_VERSION;
		ncfg->Language = NIN_LAN_AUTO;
		ncfg->MaxPads = NIN_CFG_MAXPAD;
		ncfg->MemCardBlocks = 0x2;//251 blocks
	}

	~NintendontConfiguration() {
		this->!NintendontConfiguration();
	}

	!NintendontConfiguration() {
		if (ncfg != NULL) {
			free(ncfg);
			ncfg = NULL;
		}
	}
};
