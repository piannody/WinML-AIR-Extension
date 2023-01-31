#include "FreSharpBridge.h"
namespace FreSharpBridge {

	void MarshalString(String ^ s, std::string& os) {
		using namespace R