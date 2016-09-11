package com.tele.vr.sdk.testplugin;

/**
 * @author korolyov
 *         05.09.16
 */
public class CommandPerformer {
    public static boolean perform(VrController vrController, TelegramCommand telegramCommand) {
        if (telegramCommand.commandForALias(vrController.getAlias())) {
            String command = telegramCommand.getCommand();
            TelegramCommandParams params = telegramCommand.getParams();
            if (VrController.ON_PLAY.equals(command)) {
                if (!params.isEmpty()) {
                    throw new IllegalArgumentException("onPlay: unexpected params");
                } else {
                    return vrController.onPlay();
                }
            } else if (VrController.ON_PLAY_NEXT.equals(command)) {
                if (!params.isEmpty()) {
                    throw new IllegalArgumentException("onPlayNext: unexpected params");
                } else {
                    return vrController.onPlayNext();
                }
            } else if (VrController.ON_FREEZE.equals(command)) {
                if (params.isEmpty()) {
                    throw new IllegalArgumentException("onFreeze: missed expected param");
                } else {
                    if (params.getLength() != 1) {
                        throw new IllegalArgumentException("onFreeze: unexpected params");
                    } else {
                        return vrController.onFreeze(params.getInteger(0));
                    }
                }
            } else if (VrController.ON_UNFREEZE.equals(command)) {
                if (!params.isEmpty()) {
                    throw new IllegalArgumentException("onUnfreeze: unexpected params");
                } else {
                    return vrController.onUnfreeze();
                }
            } else if (VrController.ON_GOTO.equals(command)) {
                if (params.isEmpty()) {
                    throw new IllegalArgumentException("onGoTo: missed expected param");
                } else {
                    if (params.getLength() != 1) {
                        throw new IllegalArgumentException("onGoTo: unexpected params");
                    } else {
                        return vrController.onGoTo(params.getInteger(0));
                    }
                }
            } else if (VrController.ON_WRITE_TEXT.equals(command)) {
                if (params.isEmpty()) {
                    throw new IllegalArgumentException("onWriteText: missed expected param");
                } else {
                    if (params.getLength() != 3) {
                        throw new IllegalArgumentException("onWriteText: unexpected params");
                    } else {
                        return vrController.onWriteText(params.getString(0), params.getInteger(1), params.getInteger(2));
                    }
                }
            } else if (VrController.ON_SET_CAMERA_XYZ.equals(command)) {
                if (params.isEmpty()) {
                    throw new IllegalArgumentException("onSetCameraXYZ: missed expected param");
                } else {
                    if (params.getLength() != 3) {
                        throw new IllegalArgumentException("onSetCameraXYZ: unexpected params");
                    } else {
                        return vrController.onSetCameraXYZ(params.getInteger(0), params.getInteger(1), params.getInteger(2));
                    }
                }
            } else if (VrController.GET_ALIAS.equals(command)) {
                if (!params.isEmpty()) {
                    throw new IllegalArgumentException("getAlias: unexpected params");
                } else {
                    String alias = vrController.getAlias();
                    //// TODO: 10.09.16 alias process
                    return true;
                }
            } else if (VrController.SET_ALIAS.equals(command)) {
                if (params.isEmpty()) {
                    throw new IllegalArgumentException("setAlias: missed expected param");
                } else {
                    if (params.getLength() != 1) {
                        throw new IllegalArgumentException("setAlias: unexpected params");
                    } else {
                        vrController.setAlias(params.getString(0));
                        return true;
                    }
                }
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
}
