#include <malloc.h>
#include <cstring>

#include "common/include/CommonConfig.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::IO;

public ref class NintendontConfiguration {
private:
	NIN_CFG* ncfg;
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

	void Reset() {
		memset(ncfg, 0, sizeof(NIN_CFG));
		throw gcnew NotImplementedException();
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
