#include <malloc.h>
#include <cstring>
#include <cstdint>
#include <winsock.h>

using namespace System;
using namespace System::ComponentModel;
using namespace System::IO;
using namespace System::Text;
using namespace System::Runtime::InteropServices;

namespace Nicoe {
namespace Configuration {
#if NIN_CFG_VERSION == 8
namespace V8 {
#endif
#if NIN_CFG_VERSION == 9
namespace V9 {
#endif
#if NIN_CFG_VERSION == 10
namespace V10 {
#endif

#define NIN_CFG_MAXPAD 4

typedef struct NIN_CFG
{
	uint32_t		Magicbytes;		// 0x01070CF6
	uint32_t		Version;		// 0x00000001
	uint32_t		Config;
	uint32_t		VideoMode;
	uint32_t		Language;
	char	GamePath[255];
	char	CheatPath[255];
	uint32_t		MaxPads;
	char	GameID[4];
	uint8_t			MemCardBlocks;
	int8_t			VideoScale;
	int8_t			VideoOffset;
	uint8_t			NetworkProfile;
#if NIN_CFG_VERSION >= 10
	uint32_t		WiiUGamepadSlot;
#endif
} NIN_CFG;

enum ninconfigbitpos
{
	NIN_CFG_BIT_CHEATS	= (0),
	NIN_CFG_BIT_DEBUGGER	= (1),	// Only for Wii Version
	NIN_CFG_BIT_DEBUGWAIT	= (2),	// Only for Wii Version
	NIN_CFG_BIT_MEMCARDEMU	= (3),
	NIN_CFG_BIT_CHEAT_PATH	= (4),
	NIN_CFG_BIT_FORCE_WIDE	= (5),
	NIN_CFG_BIT_FORCE_PROG	= (6),
	NIN_CFG_BIT_AUTO_BOOT	= (7),
	NIN_CFG_BIT_HID		= (8),	// Old Versions
	NIN_CFG_BIT_REMLIMIT	= (8),	// New Versions
	NIN_CFG_BIT_OSREPORT	= (9),
	NIN_CFG_BIT_USB		= (10),
	NIN_CFG_BIT_LED		= (11),
	NIN_CFG_BIT_LOG		= (12),
	NIN_CFG_BIT_LAST	= (13),

	NIN_CFG_BIT_MC_MULTI	= (13),
	NIN_CFG_BIT_NATIVE_SI	= (14),
	NIN_CFG_BIT_WIIU_WIDE	= (15),
	NIN_CFG_BIT_ARCADE_MODE = (16),
	NIN_CFG_BIT_CC_RUMBLE	= (17),
	NIN_CFG_BIT_SKIP_IPL	= (18),
	NIN_CFG_BIT_BBA_EMU		= (19),

	// Internal kernel settings.
	NIN_CFG_BIT_MC_SLOTB	= (31),	// Slot B image is loaded
};

enum ninconfig
{
	NIN_CFG_CHEATS		= (1<<NIN_CFG_BIT_CHEATS),
	NIN_CFG_DEBUGGER	= (1<<NIN_CFG_BIT_DEBUGGER),	// Only for Wii Version
	NIN_CFG_DEBUGWAIT	= (1<<NIN_CFG_BIT_DEBUGWAIT),	// Only for Wii Version
	NIN_CFG_MEMCARDEMU	= (1<<NIN_CFG_BIT_MEMCARDEMU),
	NIN_CFG_CHEAT_PATH	= (1<<NIN_CFG_BIT_CHEAT_PATH),
	NIN_CFG_FORCE_WIDE	= (1<<NIN_CFG_BIT_FORCE_WIDE),
	NIN_CFG_FORCE_PROG	= (1<<NIN_CFG_BIT_FORCE_PROG),
	NIN_CFG_AUTO_BOOT	= (1<<NIN_CFG_BIT_AUTO_BOOT),
	NIN_CFG_HID		= (1<<NIN_CFG_BIT_HID),
	NIN_CFG_REMLIMIT	= (1<<NIN_CFG_BIT_REMLIMIT),
	NIN_CFG_OSREPORT	= (1<<NIN_CFG_BIT_OSREPORT),
	NIN_CFG_USB		= (1<<NIN_CFG_BIT_USB),
	NIN_CFG_LED		= (1<<NIN_CFG_BIT_LED),		// Only for Wii Version
	NIN_CFG_LOG		= (1<<NIN_CFG_BIT_LOG),

	NIN_CFG_MC_MULTI	= (1<<NIN_CFG_BIT_MC_MULTI),
	NIN_CFG_NATIVE_SI	= (1<<NIN_CFG_BIT_NATIVE_SI),	// Only for Wii Version
	NIN_CFG_WIIU_WIDE	= (1<<NIN_CFG_BIT_WIIU_WIDE),	// Only for Wii U Version
	NIN_CFG_ARCADE_MODE	= (1<<NIN_CFG_BIT_ARCADE_MODE),
	NIN_CFG_CC_RUMBLE	= (1<<NIN_CFG_BIT_CC_RUMBLE),
	NIN_CFG_SKIP_IPL	= (1<<NIN_CFG_BIT_SKIP_IPL),
	NIN_CFG_BBA_EMU		= (1<<NIN_CFG_BIT_BBA_EMU),

	NIN_CFG_MC_SLOTB	= (1<<NIN_CFG_BIT_MC_SLOTB),
};

enum ninextrasettings
{
	NIN_SETTINGS_MAX_PADS	= NIN_CFG_BIT_LAST,
	NIN_SETTINGS_LANGUAGE,
	NIN_SETTINGS_VIDEO,
	NIN_SETTINGS_VIDEOMODE,
	NIN_SETTINGS_MEMCARDBLOCKS,
	NIN_SETTINGS_MEMCARDMULTI,
	NIN_SETTINGS_NATIVE_SI,
	NIN_SETTINGS_LAST,
};

enum ninvideomodeindex
{
//high bits
	NIN_VID_INDEX_AUTO			= (0),
	NIN_VID_INDEX_FORCE			= (1),
	NIN_VID_INDEX_NONE			= (2),
	NIN_VID_INDEX_FORCE_DF		= (4),
//low bits
	NIN_VID_INDEX_FORCE_PAL50	= (0),
	NIN_VID_INDEX_FORCE_PAL60	= (1),
	NIN_VID_INDEX_FORCE_NTSC	= (2),
	NIN_VID_INDEX_FORCE_MPAL	= (3),

	NIN_VID_INDEX_PROG			= (4),
	NIN_VID_INDEX_PATCH_PAL50	= (5),
};

enum ninvideomode
{
	NIN_VID_AUTO		= (NIN_VID_INDEX_AUTO		<<16),
	NIN_VID_FORCE		= (NIN_VID_INDEX_FORCE   	<<16),
	NIN_VID_NONE		= (NIN_VID_INDEX_NONE    	<<16),
	NIN_VID_FORCE_DF	= (NIN_VID_INDEX_FORCE_DF	<<16),

	NIN_VID_MASK		= NIN_VID_AUTO|NIN_VID_FORCE|NIN_VID_NONE|NIN_VID_FORCE_DF,

	NIN_VID_FORCE_PAL50	= (1<<NIN_VID_INDEX_FORCE_PAL50),
	NIN_VID_FORCE_PAL60	= (1<<NIN_VID_INDEX_FORCE_PAL60),
	NIN_VID_FORCE_NTSC	= (1<<NIN_VID_INDEX_FORCE_NTSC),
	NIN_VID_FORCE_MPAL	= (1<<NIN_VID_INDEX_FORCE_MPAL),

	NIN_VID_FORCE_MASK	= NIN_VID_FORCE_PAL50|NIN_VID_FORCE_PAL60|NIN_VID_FORCE_NTSC|NIN_VID_FORCE_MPAL,

	NIN_VID_PROG		= (1<<NIN_VID_INDEX_PROG),	//important to prevent blackscreens
	NIN_VID_PATCH_PAL50	= (1<<NIN_VID_INDEX_PATCH_PAL50), //different force behaviour
};

enum ninlanguage
{
	NIN_LAN_ENGLISH		= 0,
	NIN_LAN_GERMAN		= 1,
	NIN_LAN_FRENCH		= 2,
	NIN_LAN_SPANISH		= 3,
	NIN_LAN_ITALIAN		= 4,
	NIN_LAN_DUTCH		= 5,

	NIN_LAN_FIRST		= 0,
	NIN_LAN_LAST		= 6, 
/* Auto will use English for E/P region codes and 
	only other languages when these region codes are used: D/F/S/I/J  */

	NIN_LAN_AUTO		= -1, 
};

enum VideoModes
{
	GCVideoModeNone		= 0,
	GCVideoModePAL60	= 1,
	GCVideoModeNTSC		= 2,
	GCVideoModePROG		= 3,
};


//Mem0059 = 0, 0x04, 0x0080000
//Mem0123 = 1, 0x08, 0x0100000
//Mem0251 = 2, 0x10, 0x0200000
//Mem0507 = 3, 0x20, 0x0400000
//Mem1019 = 4, 0x40, 0x0800000
//Mem2043 = 5, 0x80, 0x1000000
#define MEM_CARD_MAX (5)
#define MEM_CARD_CODE(x) (1<<(x+2))
#define MEM_CARD_SIZE(x) (1<<(x+19))
#define MEM_CARD_BLOCKS(x) ((1<<(x+6))-5)

NIN_CFG nincfg_ntoh(NIN_CFG initial) {
	NIN_CFG ncfg = initial;
	ncfg.Magicbytes = ntohl(initial.Magicbytes);
	ncfg.Version = ntohl(initial.Version);
	ncfg.Config = ntohl(initial.Config);
	ncfg.VideoMode = ntohl(initial.VideoMode);
	ncfg.Language = ntohl(initial.Language);
	ncfg.MaxPads = ntohl(initial.MaxPads);
#if NIN_CFG_VERSION >= 10
	ncfg.WiiUGamepadSlot = ntohl(initial.WiiUGamepadSlot);
#endif
	return ncfg;
}

NIN_CFG nincfg_hton(NIN_CFG initial) {
	NIN_CFG ncfg = initial;
	ncfg.Magicbytes = htonl(initial.Magicbytes);
	ncfg.Version = htonl(initial.Version);
	ncfg.Config = htonl(initial.Config);
	ncfg.VideoMode = htonl(initial.VideoMode);
	ncfg.Language = htonl(initial.Language);
	ncfg.MaxPads = htonl(initial.MaxPads);
#if NIN_CFG_VERSION >= 10
	ncfg.WiiUGamepadSlot = htonl(initial.WiiUGamepadSlot);
#endif
	return ncfg;
}

String^ FromUTF8FixedBuffer(const char* ptr, size_t max_len) {
	size_t len = strnlen(ptr, max_len);
	array<unsigned char>^ temp_buffer = gcnew array<unsigned char>(len);
	for (int i = 0; i < len; i++) {
		temp_buffer[i] = ptr[i];
	}
	return Encoding::UTF8->GetString(temp_buffer);
}

void WriteToUTF8FixedBuffer(char* ptr, size_t max_len, String^ str) {
	memset(ptr, 0, max_len);
	if (str != nullptr) {
		array<unsigned char>^ temp_buffer = Encoding::UTF8->GetBytes(str);
		for (int i = 0; i < temp_buffer->Length && i < max_len; i++) {
			ptr[i] = temp_buffer[i];
		}
	}
}

public enum class NinCFGLanguage {
	ENGLISH = NIN_LAN_ENGLISH,
	GERMAN = NIN_LAN_GERMAN,
	FRENCH = NIN_LAN_FRENCH,
	SPANISH = NIN_LAN_SPANISH,
	ITALIAN = NIN_LAN_ITALIAN,
	DUTCH = NIN_LAN_DUTCH,
	AUTO = NIN_LAN_AUTO,
};

public enum class NinCFGVideoMode {
	AUTO = NIN_VID_AUTO,
	FORCE = NIN_VID_FORCE,
	NONE = NIN_VID_NONE,
	FORCE_DF = NIN_VID_FORCE_DF,
};

public enum class NinCFGForcedVideoMode {
	NONE = 0,
	PAL50 = NIN_VID_FORCE_PAL50,
	PAL60 = NIN_VID_FORCE_PAL60,
	NTSC = NIN_VID_FORCE_NTSC,
	MPAL = NIN_VID_FORCE_MPAL,
};

#define FLAGBOOL(fname, pname) virtual property bool pname { bool get() { return ncfg->Config & fname; } void set(bool value) { ncfg->Config &= ~fname; if (value) { ncfg->Config |= fname; } } }
#define STRINGPROP(fname, ptr) virtual property String^ fname { String^ get() { return FromUTF8FixedBuffer(ptr, sizeof(ptr)); } void set(String^ value) { WriteToUTF8FixedBuffer(ptr, sizeof(ptr), value); } }
#define PRIMITIVEPROP(outtype, outname, intype, inname) virtual property outtype outname { outtype get() { return (outtype)inname; } void set(outtype value) { inname = (intype)value; } }

public ref class NintendontConfiguration : INintendontConfiguration {
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
#if NIN_CFG_VERSION > 8
		if (ncfg->Version == 8)
		{	// BBA Emu disabled by default
			// BBA Config 0 by default
			ncfg->Config &= ~NIN_CFG_BBA_EMU;
			ncfg->NetworkProfile = 0;
			ncfg->Version = 9;
		}
#endif
#if NIN_CFG_VERSION > 9
		if (ncfg->Version == 9) {
			ncfg->WiiUGamepadSlot = 0;
			ncfg->Version = 10;
		}
#endif
	}
public:
	NintendontConfiguration() {
		ncfg = (NIN_CFG*)malloc(sizeof(NIN_CFG));
		Reset();
	}

	virtual void Load(Stream^ stream) {
		if (LoadNinCFG(stream) == false)
		{
			Reset();
		}
	}

	virtual void Load(array<uint8_t>^ data) {
		MemoryStream inputStream(data, false);
		Load(% inputStream);
	}

	bool Equals(Object^ obj) override {
		if (obj == nullptr || this->GetType() != obj->GetType())
			return false;

		NintendontConfiguration^ x = dynamic_cast<NintendontConfiguration^>(obj);
		return memcmp(x->ncfg, ncfg, sizeof(NIN_CFG)) == 0;
	}

	virtual property uint32_t Version {
		uint32_t get() {
			return ncfg->Version;
		}
	}

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_CHEATS, CHEATS)

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_DEBUGGER, DEBUGGER)

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_DEBUGWAIT, DEBUGWAIT)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Emulates a memory card in Slot A using a .raw file. Disable this option if you want to use a real memory card on an original Wii.")]
	FLAGBOOL(NIN_CFG_MEMCARDEMU, MEMCARDEMU)

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_CHEAT_PATH, CHEAT_PATH)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Patch games to use a 16:9 aspect ratio. (widescreen) Not all games support this option. The patches will not be applied to games that have built-in support for 16:9; use the game's options screen to configure the display mode.")]
	FLAGBOOL(NIN_CFG_FORCE_WIDE, FORCE_WIDE)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Patch games to always use 480p (progressive scan) output. Requires component cables, or an HDMI cable on Wii U.")]
	FLAGBOOL(NIN_CFG_FORCE_PROG, FORCE_PROG)

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_AUTO_BOOT, AUTO_BOOT)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Disc read speed is normally limited to the performance of the original GameCube disc drive. Unlocking read speed can allow for faster load times, but it can cause problems with games that are extremely sensitive to disc read timing.")]
	FLAGBOOL(NIN_CFG_REMLIMIT, REMLIMIT)

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_OSREPORT, OSREPORT)

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_USB, USB)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Use the drive slot LED as a disk activity indicator. The LED will be turned on when reading from or writing to the storage device. This option has no effect on Wii U, since the Wii U does not have a drive slot LED.")]
	FLAGBOOL(NIN_CFG_LED, LED)

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_LOG, LOG)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Nintendont usually uses one emulated memory card image per game. Enabling MULTI switches this to use one memory card image for all USA and PAL games, and one image for all JPN games.")]
	FLAGBOOL(NIN_CFG_MC_MULTI, MC_MULTI)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Native Control allows use of GBA link cables on original Wii systems. NOTE: Enabling Native Control will disable Bluetooth and USB HID controllers. This option is not available on Wii U.", )]
	FLAGBOOL(NIN_CFG_NATIVE_SI, NATIVE_SI)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("On Wii U, Nintendont sets the display to 4:3, which results in bars on the sides of the screen. If playing a game that supports widescreen, enable this option to set the display back to 16:9. This option has no effect on original Wii systems.")]
	FLAGBOOL(NIN_CFG_WIIU_WIDE, WIIU_WIDE)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Arcade Mode re-enables the coin slot functionality of Triforce games. To insert a coin, move the C stick in any direction.", )]
	FLAGBOOL(NIN_CFG_ARCADE_MODE, ARCADE_MODE)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Enable rumble on Wii Remotes when using the Wii Classic Controller or Wii Classic Controller Pro.", )]
	FLAGBOOL(NIN_CFG_CC_RUMBLE, CC_RUMBLE)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Skip loading the GameCube IPL, even if it's present on the storage device.", )]
	FLAGBOOL(NIN_CFG_SKIP_IPL, SKIP_IPL)

	[CategoryAttribute("Nintendont Configuration Flags")]
	[DescriptionAttribute("Enable BBA Emulation in the following supported titles including all their regions: Mario Kart: Double Dash!! Kirby Air Ride 1080 Avalanche PSO Episode 1&2 PSO Episode III Homeland", )]
	FLAGBOOL(NIN_CFG_BBA_EMU, BBA_EMU)

	[CategoryAttribute("Nintendont Configuration Flags")]
	FLAGBOOL(NIN_CFG_MC_SLOTB, MC_SLOTB)

	virtual property NinCFGVideoMode VideoMode {
		NinCFGVideoMode get() {
			return (NinCFGVideoMode)(ncfg->VideoMode & NIN_VID_MASK);
		}
		void set(NinCFGVideoMode value) {
			ncfg->VideoMode &= ~NIN_VID_MASK;
			ncfg->VideoMode |= (uint32_t)value & NIN_VID_MASK;
		}
	}

	virtual property NinCFGForcedVideoMode ForcedVideoMode {
		NinCFGForcedVideoMode get() {
			return (NinCFGForcedVideoMode)(ncfg->VideoMode & NIN_VID_FORCE_MASK);
		}
		void set(NinCFGForcedVideoMode value) {
			ncfg->VideoMode &= ~NIN_VID_FORCE_MASK;
			ncfg->VideoMode |= (uint32_t)value & NIN_VID_FORCE_MASK;
		}
	}

	virtual property bool ProgressiveScan {
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

	virtual property bool PAL50Patch {
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
	PRIMITIVEPROP(NinCFGLanguage, Language, uint32_t, ncfg->Language)

	STRINGPROP(GamePath, ncfg->GamePath)
	STRINGPROP(CheatPath, ncfg->CheatPath)

	[DescriptionAttribute("Set the maximum number of native GameCube controller ports to use on Wii. This should usually be kept at 4 to enable all ports. This option has no effect on Wii U and Wii Family Edition systems.")]
	PRIMITIVEPROP(uint32_t, MaximumNativePads, uint32_t, ncfg->MaxPads)

	STRINGPROP(GameID, ncfg->GameID)

	[DescriptionAttribute("Default size for new memory card images. NOTE: Sizes larger than 251 blocks are known to cause issues.")]
	PRIMITIVEPROP(uint32_t, MemoryCardType, uint32_t, ncfg->MemCardBlocks)

	[DescriptionAttribute("Used to control the video width in pixels. Valid options range from 40 (640px) to 120 (720px), or 0 for Auto.")]
	PRIMITIVEPROP(int8_t, VideoScale, int8_t, ncfg->VideoScale)

	[DescriptionAttribute("Horizontal video offest. Valid options range from -20 to 20 (inclusive).")]
	PRIMITIVEPROP(int8_t, VideoOffset, int8_t, ncfg->VideoOffset)

#if NIN_CFG_VERSION >= 9
	[DescriptionAttribute("Force a Network Profile to use for BBA Emulation, this option only works on the original Wii because on Wii U the profiles are managed by the Wii U Menu. This means you can even use profiles that cannot connect to the internet.")]
	PRIMITIVEPROP(uint8_t, NetworkProfile, uint8_t, ncfg->NetworkProfile)
#endif

#if NIN_CFG_VERSION >= 10
	[DescriptionAttribute("Indicates the GameCube controller to assign Wii U GamePad inputs to: 0=P1, 1=P2, 2=P3, 3=P4.")]
	PRIMITIVEPROP(uint32_t, WiiUGamepadSlot, uint32_t, ncfg->WiiUGamepadSlot)
#endif

	virtual property int32_t MemoryCardSize {
		int32_t get() {
			return MEM_CARD_SIZE(ncfg->MemCardBlocks);
		}
	}

	virtual property int32_t MemoryCardBlocks {
		int32_t get() {
			return MEM_CARD_BLOCKS(ncfg->MemCardBlocks);
		}
	}

	virtual property String^ VideoWidth {
		String^ get() {
			return ncfg->VideoScale < 40 || ncfg->VideoScale > 120 ? "Auto" : (ncfg->VideoScale + 600).ToString();
		}
	}

	virtual array<uint8_t>^ Export() {
		NIN_CFG toExport = nincfg_hton(*ncfg);

		array<uint8_t>^ arr = gcnew array<uint8_t>(sizeof(NIN_CFG));
		pin_ptr<uint8_t> pin = &arr[0];
		memcpy(pin, &toExport, sizeof(NIN_CFG));

		return arr;
	}

	virtual void Reset() {
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

}
}
}