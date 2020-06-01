using System;
using System.Collections.Generic;
using System.Text;

namespace EntityUniProjectTrain
{
    // Шлях до БД може відрізнятися на різних ОС
    // Для кожної ОС напишемо різні реалізації інтерфейсу
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
