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
        trace("