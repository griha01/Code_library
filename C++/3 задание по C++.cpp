#include <iostream>
#include <Windows.h>
#include <string>
using namespace std;

class Orders {
public:
    int number;
    string address;
    string fullname;
    string isCompleted;
    Orders(int number, string address, string fullname, string isCompleted)
    {
        this->number = number;
        this->fullname = fullname;
        this->address = address;
        this->isCompleted = isCompleted;
    }
    Orders()
    {
        this->number = 0;
        this->fullname = "";
        this->address = "";
        this->isCompleted = "";
    }
    bool operator < (Orders& order)
    {
        return (isCompleted < order.isCompleted) || (isCompleted == order.isCompleted) && (number < order.number);
    }
    void Show()
    {
        cout << number << " " << address << " " << fullname << " " << isCompleted;
    }
};
void ShowAllOrders(Orders orders[], int arrayLength) {
    for (int i = 0; i < arrayLength; i++)
    {
        orders[i].Show();
        cout << endl;
    }
}
template <class T> void Shell(T array[], int size)
{
    int step, i, j;
    T temp;

    // Выбор шага
    for (step = size / 2; step > 0; step /= 2)
    {
        // Перечисление элементов, которые сортируются на определённом шаге
        for (i = step; i < size; i++)
        {
            // Перестановка элементов внутри подсписка, пока i-тый не будет отсортирован
            for (j = i - step; j >= 0 && array[j] < array[j + step]; j -= step)
            {
                temp = array[j];
                array[j] = array[j + step];
                array[j + step] = temp;
            }
        }
    }
}
int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Orders orders[] = {
    Orders(1009,"г.Котельники, ул.Новая, д.17, кв.123         ","Иванов Сергей ","Выполнен"),
    Orders(1010,"г.Дзержинский, ул.Гарибальди, д.15,кв.89     ","Сидоров Никита","В работе"),
    Orders(1011,"Москва, Большой факельный пер., д.38А        ","Петрова Настя ","В работе"),
    Orders(1023,"г.Котельники, мкр. Силикат, д.7, кв.3        ","Бендер Остап  ","Выполнен"),
    Orders(1045,"Москва, Проспект маршала Жукова,  д.23, кв.78","Васильев Петр ","Выполнен"),
    Orders(1121,"Москва, Проспект мира, д. 108, кор. 4, кв.86 ","Федоров Юрий  ","В работе"),
    };
   ShowAllOrders(orders, 6);
   Shell(orders, 6);
   cout << endl;
   ShowAllOrders(orders, 6);
    system("pause");
    return 0;
}
