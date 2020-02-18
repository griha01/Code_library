#include <iostream>
#include <Windows.h>
#include <string>
#include <cmath>
using namespace std;
class list
{
private:
	double a;
	list* next;
	list* prev;
public:
	list()
	{
		this->a = 0;
		next = NULL;
		prev = NULL;
	}
	list(double a)
	{
		this->a = a;
		next = NULL;
		prev = NULL;
	}
	list(double a, list* head)
	{
		list* p = new list(a);
		if (head->next == NULL)
		{
			head->next = p;
			head->prev = p;
		}
		else
		{
			p->next = head->next;
			head->next = p;
			list* q = p->next;
			q->prev = p;
		}
	}
	void show()
	{
		list* temp(0);
		for (temp =this->next; temp != NULL; temp = temp->next)
		{
			cout << temp->a << endl;
		}
		cout << endl;
	}
	void show_list()
	{
		cout << a << endl;
	}
	list* search(int n)
	{
		int i=1;
		list* temp(0);
		for (temp = this->next; i < n; temp = temp->next, i++);
		return temp;
	}
	void Delete(int n)
	{
		list* temp = search(n);
		list* temp_next = temp->next;
		list* temp_prev = temp->prev;
		if (temp->next != NULL)
		{
			temp_next->prev = temp_prev;
			cout << "TEST_next" << endl;
		}
		if (temp->prev != NULL) 
		{
			temp_prev->next = temp_next;
			cout << "TEST_prev" << endl;
		}
	}
};
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	list head(0);
	list A1(22,&head);
	list A2(6, &head);
	list A3(4, &head);
	head.show();
	head.Delete(1);
	head.show();

	system("pause");
	return 0;
}
