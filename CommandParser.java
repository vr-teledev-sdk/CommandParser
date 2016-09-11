package com.tele.vr.sdk.testplugin;

import java.util.*;

/**
 * @author korolyov
 *         05.09.16
 */
public final class CommandParser {

    private CommandParser() {
    }

    private static TelegramCommand parseLine(String command) {
        Set<String> aliasSet = new HashSet<String>();
        int openBracket = command.indexOf('[');
        if (openBracket != -1) {
            int closeBracket = command.indexOf(']');
            if (openBracket == 0 && openBracket + 1 < closeBracket) {
                String[] aliases = command.substring(openBracket, closeBracket + 1).split("\\s+");
                Collections.addAll(aliasSet, aliases);
                command = command.substring(closeBracket + 1);
            } else {
                throw new IllegalArgumentException("Bad alias syntax");
            }
        }
        String[] tokens = command.trim().split("\\s+");
        String[] params = new String[tokens.length - 1];
        System.arraycopy(tokens, 1, params, 0, tokens.length - 1);
        return new TelegramCommand(aliasSet, tokens[0], TelegramCommandParams.of(params));
    }

    public static List<TelegramCommand> parse(String commands) {
        commands = commands.toLowerCase();
        String[] lines = commands.split(System.getProperty("line.separator"));
        List<TelegramCommand> list = new ArrayList<TelegramCommand>();
        for (String line : lines) {
            list.add(parseLine(line));
        }
        return list;
    }



}
