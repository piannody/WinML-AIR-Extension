package com.tuarua {
import com.tuarua.fre.ANEError;
import flash.events.EventDispatcher;
import flash.events.StatusEvent;
import flash.external.ExtensionContext;

public class MLANE extends EventDispatcher {
    private static const NAME:String = "MLANE";
    private var ctx:ExtensionContext;
    private static const TRACE:String = "TRACE";
    public function MLANE() {
        trace("[" + NAME + "] Initializing ANE...");
        try {
            ctx = ExtensionContext.createExtensionContext("com.tuarua." + NAME, null);
            ctx.addEventListener(StatusEvent.STATUS, gotEvent);
        } catch (e:Error) {
            trace(e.name);
            trace(e.message);
            trace(e.getStackTrace());
            trace(e.errorID);
            trace("[" + NAME + "] ANE Not loaded properly.  Future calls will fail.");
        }
    }

    private function gotEvent(event:StatusEvent):void {
        switch (event.level) {
   