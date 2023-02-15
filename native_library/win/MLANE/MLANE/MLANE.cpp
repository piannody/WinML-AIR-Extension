#include "MLANE.h"
#include "FreSharpBridge.h"

extern "C" {
	CONTEXT_INIT(TRCML) {
		FREBRIDGE_INIT

		/**************************************************************************/
		/******* MAKE SURE TO ADD FUNCTIONS HERE THE SAME AS MAINCONTROL