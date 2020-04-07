#include <iostream>
#include <Windows.h>
#include <string>
using namespace std;

class Children {
public:
    int number;
    string fullname;
    string date;
    string group;
    Children(int number, string fullname, string date, string group)
    {
        this->number = number;
        this->fullname = fullname;
        this->date = date;
        this->group = group;
    }
    Children()
    {
        this->number = 0;
        this->fullname = "";
        this->date = "";
        this->group = "";
    }
    bool operator < (Children& children)
    {
        return (group < children.group) || (group == children.group) && (fullname < children.fullname);
    }
    void Show()
    {
        cout << number << " " << fullname << " " << date << " " << group;
    }
};
void ShowAllChildrens(Children children[], int arrayLength) {
    for (int i = 0; i < arrayLength; i++)
    {
        children[i].Show();
        cout << endl;
    }
}
template <class T> void InsertionSort(T data[], int lenD) {
    int i;
    int k;
    Children temp;
    for (int j = 1; j < lenD; j++) {
        temp = data[j];
        for (i = j; i > 0; i--)
        {
            if (data[i - 1] < temp)
            {
                break;
            }
            data[i] = data[i - 1];
        }
        data[i] = temp;
    }
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Children childrens[] = {
    Children(1001,"Иванов Алеша   ","2009-10-30","Старшая"),
    Children(1002,"Сидорова Наташа","2008-02-27","Старшая"),
    Children(1006,"Петрова Катя   ","2009-09-17","Старшая"),
    Children(1003,"Петров Артем   ","2006-07-23","Младшая"),
    Children(1004,"Фролов Антон   ","2008-12-31","Младшая"),
    Children(1007,"Аволов Антон   ","2008-12-31","Младшая"),
    Children(1007,"Аболов Антон   ","2008-12-31","Младшая"),
    Children(1005,"Федорова Ирина ","2009-09-12","Подготовительная")
    };
    ShowAllChildrens(childrens, 8);
    InsertionSort(childrens, 8);
    cout << endl;
    ShowAllChildrens(childrens, 8);
    system("pause");
    return 0;
}

