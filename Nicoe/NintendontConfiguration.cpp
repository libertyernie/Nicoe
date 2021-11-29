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

#define FLAGBOOL(fname, pname) property bool pname { bool get() { return ncfg->Config & fname; } void set(bool value) { ncfg->Config &= ~fname; if (value) { ncfg->Config |= fname; } } }

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

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_CHEATS, CHEATS)

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_DEBUGGER, DEBUGGER)

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_DEBUGWAIT, DEBUGWAIT)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Emulates a memory card in Slot A using a .raw file. Disable this option if you want to use a real memory card on an original Wii.")]
	FLAGBOOL(NIN_CFG_MEMCARDEMU, MEMCARDEMU)

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_CHEAT_PATH, CHEAT_PATH)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Patch games to use a 16:9 aspect ratio. (widescreen) Not all games support this option. The patches will not be applied to games that have built-in support for 16:9; use the game's options screen to configure the display mode.")]
	FLAGBOOL(NIN_CFG_FORCE_WIDE, FORCE_WIDE)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Patch games to always use 480p (progressive scan) output. Requires component cables, or an HDMI cable on Wii U.")]
	FLAGBOOL(NIN_CFG_FORCE_PROG, FORCE_PROG)

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_AUTO_BOOT, AUTO_BOOT)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Disc read speed is normally limited to the performance of the original GameCube disc drive. Unlocking read speed can allow for faster load times, but it can cause problems with games that are extremely sensitive to disc read timing.")]
	FLAGBOOL(NIN_CFG_REMLIMIT, REMLIMIT)

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_OSREPORT, OSREPORT)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("On Wii U, Nintendont sets the display to 4:3, which results in bars on the sides of the screen. If playing a game that supports widescreen, enable this option to set the display back to 16:9. This option has no effect on original Wii systems.")]
	FLAGBOOL(NIN_CFG_USB, USB)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Use the drive slot LED as a disk activity indicator. The LED will be turned on when reading from or writing to the storage device. This option has no effect on Wii U, since the Wii U does not have a drive slot LED.")]
	FLAGBOOL(NIN_CFG_LED, LED)

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_LOG, LOG)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Nintendont usually uses one emulated memory card image per game. Enabling MULTI switches this to use one memory card image for all USA and PAL games, and one image for all JPN games.")]
	FLAGBOOL(NIN_CFG_MC_MULTI, MC_MULTI)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Native Control allows use of GBA link cables on original Wii systems. NOTE: Enabling Native Control will disable Bluetooth and USB HID controllers. This option is not available on Wii U.", )]
	FLAGBOOL(NIN_CFG_NATIVE_SI, NATIVE_SI)

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_WIIU_WIDE, WIIU_WIDE)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Arcade Mode re-enables the coin slot functionality of Triforce games. To insert a coin, move the C stick in any direction.", )]
	FLAGBOOL(NIN_CFG_ARCADE_MODE, ARCADE_MODE)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Enable rumble on Wii Remotes when using the Wii Classic Controller or Wii Classic Controller Pro.", )]
	FLAGBOOL(NIN_CFG_CC_RUMBLE, CC_RUMBLE)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Skip loading the GameCube IPL, even if it's present on the storage device.", )]
	FLAGBOOL(NIN_CFG_SKIP_IPL, SKIP_IPL)

	[CategoryAttribute("Flags")]
	[DescriptionAttribute("Enable BBA Emulation in the following supported titles including all their regions: Mario Kart: Double Dash!! Kirby Air Ride 1080 Avalanche PSO Episode 1&2 PSO Episode III Homeland", )]
	FLAGBOOL(NIN_CFG_BBA_EMU, BBA_EMU)

	[CategoryAttribute("Flags")]
	FLAGBOOL(NIN_CFG_MC_SLOTB, MC_SLOTB)

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

	property String^ GamePath {
		String^ get() {
			return FromUTF8FixedBuffer(ncfg->GamePath, sizeof(ncfg->GamePath));
		}
		void set(String^ value) {
			WriteToUTF8FixedBuffer(ncfg->GamePath, sizeof(ncfg->GamePath), value);
		}
	}

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

	property String^ GameID {
		String^ get() {
			return FromUTF8FixedBuffer(ncfg->GameID, sizeof(ncfg->GameID));
		}
		void set(String^ value) {
			WriteToUTF8FixedBuffer(ncfg->GameID, sizeof(ncfg->GameID), value);
		}
	}

	[DescriptionAttribute("Default size for new memory card images. NOTE: Sizes larger than 251 blocks are known to cause issues.")]
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

	[DescriptionAttribute("Force a Network Profile to use for BBA Emulation, this option only works on the original Wii because on Wii U the profiles are managed by the Wii U Menu. This means you can even use profiles that cannot connect to the internet.")]
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
