#pragma once

System::String^ FromUTF8FixedBuffer(const char* ptr, size_t max_len);
void WriteToUTF8FixedBuffer(char* ptr, size_t max_len, System::String^ str);
