#include "FreSharpBridge.h"
namespace FreSharpBridge {

	void MarshalString(String ^ s, std::string& os) {
		using namespace Runtime::InteropServices;
		const char* chars =
			reinterpret_cast<const char*>(Marshal::StringToHGlobalAnsi(s).ToPointer(