package com.tele.vr.sdk.testplugin;

import java.util.Arrays;

/**
 * @author korolyov
 *         05.09.16
 */
public class TelegramCommandParams {
    private String[] params;
    private TelegramCommandParams() {
    }

    public boolean isEmpty() {
        return params.length == 0;
    }

    public String getString(int index) {
        return params[index];
    }

    public long getLong(int index) {
        return Long.parseLong(params[index]);
    }

    public int getInteger(int index) {
        return Integer.parseInt(params[index]);
    }

    public int getLength() {
        return params.length;
    }

    public static TelegramCommandParams of(String[] params) {
        TelegramCommandParams telegramCommandParams = new TelegramCommandParams();
        telegramCommandParams.params = params;
        if (telegramCommandParams.params == null) {
            telegramCommandParams.params = new String[0];
        }
        return telegramCommandParams;
    }

    @Override
    public String toString() {
        return "TelegramCommandParams{" +
            "params=" + Arrays.toString(params) +
            '}';
    }
}
