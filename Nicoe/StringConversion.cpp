#include <string.h>

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Text;

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
	array<unsigned char>^ temp_buffer = Encoding::UTF8->GetBytes(str);
	for (int i = 0; i < temp_buffer->Length && i < max_len; i++) {
		ptr[i] = temp_buffer[i];
	}
}
