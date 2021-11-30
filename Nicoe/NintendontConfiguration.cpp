#include <malloc.h>
#include <cstring>

#include "CommonConfig.h"
#include "ByteOrderConversion.h"
#include "StringConversion.h"
#include "Enums.h"

using namespace System;
using namespace System::ComponentModel;
using namespace System::Runtime::InteropServices;
using namespace System::IO;

public ref class NintendontConfiguration {
private:
	NIN_CFG* ncfg;

	bool LoadNinCFG(Stream^ stream)
	{
		bool ConfigLoaded = true;

		array<uint8_t>^ temp_buffer = gcnew array<uint8_t>(sizeof(NIN_CFG));
		int BytesRead = stream->Read(temp_buffer, 0, temp_buffer->Length);

		IntPtr destination(ncfg);
		Marshal::Copy(temp_buffer, 0, destination, sizeof(NIN_CFG));

		*ncfg = nincfg_ntoh(*ncfg);

		switch (ncfg->Version) {
		case 2:
			if (BytesRead != 540)
				ConfigLoaded = false;
			break;

		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			if (BytesRead != 544)
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
		Reset();
	}

	void Load(Stream^ stream) {
		if (LoadNinCFG(stream) == false)
		{
			Reset();
		}
	}

	void Load(array<uint8_t>^ data) {
		MemoryStream inputStream(data, false);
		Load(% inputStream);
	}

	bool Equals(Object^ obj) override {
		if (obj == nullptr || this->GetType() != obj->GetType())
			return false;

		NintendontConfiguration^ x = dynamic_cast<NintendontConfiguration^>(obj);
		return memcmp(x->ncfg, ncfg, sizeof(NIN_CFG)) == 0;
	}

	property NinCFGFlags Flags {
		NinCFGFlags get() {
			uint32_t x = (uint32_t)ncfg->Config;
			System::Console::WriteLine(x);
			return (NinCFGFlags)ncfg->Config;
		}
		void set(NinCFGFlags value) {
			ncfg->Config = (uint32_t)value;
		}
	}

	[DescriptionAttribute("How to handle video output - Auto, Force, None, or Force (Deflicker).")]
	property NinCFGVideoMode VideoMode {
		NinCFGVideoMode get() {
			return (NinCFGVideoMode)(ncfg->VideoMode & NIN_VID_MASK);
		}
		void set(NinCFGVideoMode value) {
			ncfg->VideoMode &= ~NIN_VID_MASK;
			ncfg->VideoMode |= (uint32_t)value & NIN_VID_MASK;
		}
	}

	[DescriptionAttribute("The video mode to use if output is forced.")]
	property NinCFGForcedVideoMode ForcedVideoMode {
		NinCFGForcedVideoMode get() {
			return (NinCFGForcedVideoMode)(ncfg->VideoMode & NIN_VID_FORCE_MASK);
		}
		void set(NinCFGForcedVideoMode value) {
			ncfg->VideoMode &= ~NIN_VID_FORCE_MASK;
			ncfg->VideoMode |= (uint32_t)value & NIN_VID_FORCE_MASK;
		}
	}

	[DescriptionAttribute("Whether to use progressive scan.")]
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

	[DescriptionAttribute("Whether to patch the game to force PAL50.")]
	property bool PAL50Patch {
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

	[DescriptionAttribute("The system language. This option is normally only found on PAL GameCubes, so it usually won't have an effect on NTSC games.")]
	property NinCFGLanguage Language {
		NinCFGLanguage get() {
			return (NinCFGLanguage)ncfg->Language;
		}
		void set(NinCFGLanguage value) {
			ncfg->Language = (uint32_t)value;
		}
	}

	[DescriptionAttribute("The path to the game's disc image, if any.")]
	property String^ GamePath {
		String^ get() {
			return FromUTF8FixedBuffer(ncfg->GamePath, sizeof(ncfg->GamePath));
		}
		void set(String^ value) {
			WriteToUTF8FixedBuffer(ncfg->GamePath, sizeof(ncfg->GamePath), value);
		}
	}

	[DescriptionAttribute("The path to the game's cheat file, if any.")]
	property String^ CheatPath {
		String^ get() {
			return FromUTF8FixedBuffer(ncfg->CheatPath, sizeof(ncfg->CheatPath));
		}
		void set(String^ value) {
			WriteToUTF8FixedBuffer(ncfg->CheatPath, sizeof(ncfg->CheatPath), value);
		}
	}

	[DescriptionAttribute("Set the maximum number of native GameCube controller ports to use on Wii. This should usually be kept at 4 to enable all ports. This option has no effect on Wii U and Wii Family Edition systems.")]
	property uint32_t MaximumNativePads {
		uint32_t get() {
			return ncfg->MaxPads;
		}
		void set(uint32_t value) {
			ncfg->MaxPads = value;
		}
	}

	[DescriptionAttribute("The four-character game ID, if any.")]
	property String^ GameID {
		String^ get() {
			return FromUTF8FixedBuffer(ncfg->GameID, sizeof(ncfg->GameID));
		}
		void set(String^ value) {
			WriteToUTF8FixedBuffer(ncfg->GameID, sizeof(ncfg->GameID), value);
		}
	}

	[DescriptionAttribute("Indicates the type of emulated memory card to use. Valid options are 0, 2, and 4.")]
	property uint8_t MemoryCardType {
		uint8_t get() {
			return ncfg->MemCardBlocks;
		}
		void set(uint8_t value) {
			ncfg->MemCardBlocks = value;
		}
	}

	property int32_t MemoryCardSize {
		int32_t get() {
			return MEM_CARD_SIZE(ncfg->MemCardBlocks);
		}
	}

	property int32_t MemoryCardBlocks {
		int32_t get() {
			return MEM_CARD_BLOCKS(ncfg->MemCardBlocks);
		}
	}

	[DescriptionAttribute("Used to control the video width in pixels. Valid options range from 40 (640px) to 120 (720px), or 0 for Auto.")]
	property int8_t VideoScale {
		int8_t get() {
			return ncfg->VideoScale;
		}
		void set(int8_t value) {
			ncfg->VideoScale = value;
		}
	}

	property String^ VideoWidth {
		String^ get() {
			return ncfg->VideoScale < 40 || ncfg->VideoScale > 120 ? "Auto" : (ncfg->VideoScale + 600).ToString();
		}
	}

	[DescriptionAttribute("Horizontal video offest. Valid options range from -20 to 20 (inclusive).")]
	property int8_t VideoOffset {
		int8_t get() {
			return ncfg->VideoOffset;
		}
		void set(int8_t value) {
			ncfg->VideoOffset = value;
		}
	}

	[DescriptionAttribute("The network profile in the Wii's system settings to use for BBA emulation, or 0 for Auto.")]
	property uint8_t NetworkProfile {
		uint8_t get() {
			return ncfg->NetworkProfile;
		}
		void set(uint8_t value) {
			ncfg->NetworkProfile = value;
		}
	}

	[DescriptionAttribute("Indicates the GameCube controller to assign Wii U GamePad inputs to: 0=P1, 1=P2, 2=P3, 3=P4.")]
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
