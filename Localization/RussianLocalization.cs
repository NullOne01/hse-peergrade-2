using System;
using System.Collections.Generic;

namespace HSEPeergrade2.Localization
{
    /// <summary>
    ///     Class of russian localization.
    /// </summary>
    public class RussianLocalization : DefaultLocalization
    {
        public RussianLocalization()
        {
            localDict = new Dictionary<string, string>
            {
                {"TEST", "Тест. "},
                {"UNDEFINED", "Неопределенно. "},
                {
                    "HELP", "Пару подсказок: 1) PATH_FILE означает путь к файлу. Пример: \"KEK/kek.txt\". " + Environment.NewLine +
                            "2) PATH_DIR означает путь к директории. Пример: \"KEK\". " + Environment.NewLine +
                            "3) Можно использовать абсолютные и относительные пути." + Environment.NewLine +
                            "" + Environment.NewLine +
                            "help - выводит это меню." + Environment.NewLine +
                            "diskShow - отображает все диски. " + Environment.NewLine +
                            "cd \"PATH_DIR\" - выбирает директорию. " + Environment.NewLine +
                            "ls - показывает имена файлов и папок в данной директории. " + Environment.NewLine +
                            "print \"PATH_FILE\" - выводит содержимое файла в кодировке UTF-8" + Environment.NewLine +
                            "print \"PATH_FILE\" \"UTF-8/UTF-7/UTF-32/ASCII\" - " +
                            "выводит содержимое файла в одной из кодировок (UTF-8/UTF-7/UTF-32/ASCII). " +
                            Environment.NewLine +
                            "copy \"PATH_FILE\" \"PATH_FILE\" - копирует первый файл на место второго файла. " +
                            Environment.NewLine +
                            "move \"PATH_FILE\" \"PATH_DIR\" - перемещает файл в директорию. " + Environment.NewLine +
                            "delete \"PATH_FILE\" - удаляет файл. " + Environment.NewLine +
                            "create \"PATH_FILE\" \"SOME_TEXT\" - создаёт файла с текстом внутри в кодировке UTF-8. " +
                            Environment.NewLine +
                            "create \"PATH_FILE\" \"SOME_TEXT\" \"UTF-8/UTF-7/UTF-32/ASCII\" - " +
                            "создаёт файла с текстом внутри в выбранной кодировке (UTF-8/UTF-7/UTF-32/ASCII). " +
                            Environment.NewLine +
                            "concat \"PATH_FILE\" \"PATH_FILE\"... - объединяет и выводит файлы, " +
                            "количество файлов не ограничено. " + Environment.NewLine +
                            "switchLang - меняет язык между Русским и Английским языками (Дополнительный функционал)."
                },
                {"WRONG_ARGUMENTS", "Ошибка: неверные аргументы. "},
                {"WRONG_ARGUMENTS_IO", "Ошибка: некорректная директория."},
                {"FILE_NOT_FOUND", "Ошибка: файл не найден."},
                {"DIR_NOT_FOUND", "Ошибка: директория не найдена."},
                {"NO_COMMAND", "Ошибка: неизвестная команда. "},
                {"INVALID_PATH", "Ошибка: некорректный путь. "},
                {"COPY_FILE_DOESNT_EXIST", "Ошибка: копируемый файл не существует. "},
                {"COPY_FILE_ALREADY_EXISTS", "Ошибка: файл, куда копируем, уже существует. "},
                {"MOVE_FILE_DOESNT_EXIST", "Ошибка: перемещаемый файл не существует. "},
                {"MOVE_FILE_ALREADY_EXISTS", "Ошибка: файл, куда перемещаем, уже существует. "},
                {"FILE_ALREADY_EXISTS", "Ошибка: файл уже существует. "},
                {"ACCESS_PROBLEM", "Ошибка: нет доступа. "},
                {"ESC_TO_EXIT", "Нажми ESC чтобы выйти. Иначе напиши что-нибудь... "},
                {"DIRECTORIES", "Директории: "},
                {"FILES", "Файлы: "},
                {"NO_DIRECTORIES", "Здесь нет директорий. "},
                {"NO_FILES", "Здесь нет файлов. "},
                {"INVALID_ENCODING", "Ошибка: неизвестная кодировка. "},
                {"COMMAND_SUCCESS", "Команда выполнена успешно. "}
            };
        }
    }
}