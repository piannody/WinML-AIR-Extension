#pragma once
#ifndef MAP_FUNCTION
#define MAP_FUNCTION(fn) { (const uint8_t*)(#fn), (#fn), &callSharpFunction }
#endif
#ifndef EXTENSION_INIT_DECL
#define EXTENSION_INIT_DECL(prefix) void (prefix##ExtInizer) (void **extData, FREContextInitializer *ctxInitializer, FREContextFinalizer *ctxFinalizer)
#endif

#ifndef EXTENSION_FIN_DECL
#define EXTENSION_FIN_DECL(prefix) void (prefix##ExtFinizer) (void *extData)
#endif

#ifndef EXTENSION_FIN
#define EXTENSION_FIN(prefix) void (prefix##ExtFinizer) (void *extData) { \
FREContext nullCTX = 0; \
prefix##_contextFinalizer(nullCTX); \
}
#endif

#ifndef CONTEXT_FIN
#define CONTEXT_FIN(prefix) void (prefix##_contextFinalizer) (FRE