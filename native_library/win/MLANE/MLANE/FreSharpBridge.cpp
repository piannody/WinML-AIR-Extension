#include "FreSharpBridge.h"
namespace FreSharpBridge {

	void MarshalString(String ^ s, std::string& os) {
		using namespace Runtime::InteropServices;
		const char* chars =
			reinterpret_cast<const char*>(Marshal::StringToHGlobalAnsi(s).ToPointer());
		os = chars;
		// ReSharper disable once CppCStyleCast
		Marshal::FreeHGlobal(FREObjectCLR((void*)chars));
	}

	array<FREObjectCLR>^ MarshalFREArray(array<FREObject>^ argv, uint32_t argc) {
		auto arr = gcnew a