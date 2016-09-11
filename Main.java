package com.tele.vr.sdk.testplugin;

import java.util.List;

/**
 * @author korolyov
 *         11.09.16
 */
public class Main {
    public static void main(String[] args) {
        String commands = "[first second] play\n" +
            "playNext\n" +
            "freeze 100\n";
        List<TelegramCommand> telegramCommands = CommandParser.parse(commands);
        for (TelegramCommand telegramCommand : telegramCommands) {
            System.out.println(telegramCommand);
        }
    }
}
