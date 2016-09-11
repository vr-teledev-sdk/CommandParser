package com.tele.vr.sdk.testplugin;

/**
 * @author korolyov
 *         14.08.16
 */
public interface VrController {
    String ON_PLAY = "play";
    String ON_PLAY_NEXT = "playnext";
    String ON_WRITE_TEXT = "onwritetext";
    String ON_FREEZE = "onfreeze";
    String ON_UNFREEZE = "onunfreeze";
    String ON_GOTO = "ongoto";
    String ON_SET_CAMERA_XYZ = "onsetcameraxyz";
    String GET_ALIAS = "getalias";
    String SET_ALIAS = "setalias";

    boolean onPlay();
    boolean onPlayNext();
    boolean onWriteText (String s, int x, int y);
    boolean onUnfreeze();
    boolean onFreeze(int ms);
    boolean onGoTo (int step);
    boolean onSetCameraXYZ (int x, int y, int z);
    void setAlias(String alias);
    String getAlias();

    //требуется понять в каком формате мы будем оперировать изображениями, звуками. Какими классами можно пользоваться для этого?
    //void onOutImage(Image image, int x, int y)
    //void onGetMicrophone (int n);
    //void onGetScreen();

}
