#pragma once
#ifndef MAP_FUNCTION
#define MAP_FUNCTION(fn) { (const uint8_t*)(#fn), (#fn), &callSharpFunction }
#endif
#ifndef EXTENSION_INIT_DECL
#define EXTENSION_INIT_DECL(prefix) void (prefix##ExtInizer) (void **extData, FREContextInitializer *ctxInitializer, FREContextFinalizer *ctxFinalizer)
#endif

#ifndef EXTENSION_F