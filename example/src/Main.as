package {
import com.tuarua.FreSharp;
import com.tuarua.MLANE;
import com.tuarua.MLEvent;
import com.tuarua.fre.ANEError;

import flash.desktop.NativeApplication;

import flash.display.Bitmap;

import flash.display.Sprite;
import flash.display.StageAlign;
import flash.display.StageScaleMode;
import flash.events.Event;
import flash.events.MouseEvent;
import flash.filesystem.File;
import flash.text.AntiAliasType;
import flash.text.Font;
import flash.text.TextField;
import flash.text.TextFormat;

import views.SimpleButton;

[SWF(width="700", height="700", frameRate="60", backgroundColor="#FFFFFF")]
public class Main extends Sprite {
    private var freSharpANE:FreSharp = new FreSharp();//must create before all others
    [Embed(source="cat.jpg")]
    public static const TestImage:Class;

    public static const FONT:Font = new FiraSansSemiBold();
    private var btnZip:SimpleButton = new SimpleButton("Detect Image");
    private var statusLabel:TextField = new TextField();
    private var ane:MLANE = new MLANE();
    private var testImage:Bitmap = new TestImage() as Bitmap;

    public function Main() {
        stage.align = StageAlign.TOP_LEFT;
        stage.scaleMode = StageScaleMode.NO_SCALE;

        NativeApplication.nativeApplication.add