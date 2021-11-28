#include <winsock.h>

#include "CommonConfig.h"

NIN_CFG nincfg_ntoh(NIN_CFG initial) {
	NIN_CFG ncfg = initial;
	ncfg.Magicbytes = ntohl(initial.Magicbytes);
	ncfg.Version = ntohl(initial.Version);
	ncfg.Config = ntohl(initial.Config);
	ncfg.VideoMode = ntohl(initial.VideoMode);
	ncfg.Language = ntohl(initial.Language);
	ncfg.MaxPads = ntohl(initial.MaxPads);
	ncfg.WiiUGamepadSlot = ntohl(initial.WiiUGamepadSlot);
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
	ncfg.WiiUGamepadSlot = htonl(initial.WiiUGamepadSlot);
	return ncfg;
}
