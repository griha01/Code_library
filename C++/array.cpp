#include <iostream>
#include <Windows.h>
#include <string>
#include <cmath>
using namespace std;
class list
{
protected:
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
	void add(double a)
	{
		list* p = new list(a);
		if (next)
		{
			next->prev = p;
			p->next = next;
			next = p;

		}
		else
		{
			next = p;
			next = p;
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
	list* search_first(int n)
	{
		list* temp(0);
		temp = this->next;
		while (temp->a != n)
		{
			temp = temp->next;
		}
		return temp;
	}
	list* search_last(int n) // недоделан
	{
		list* temp(0);
		temp = this->prev;
		while (temp->a != n)
		{
			temp = temp->prev;
		}
		return temp;
	}
	void Delete(int n)
	{
			list* temp = search_last(n);
			list* temp_next = temp->next;
			list* temp_prev = temp->prev;
			

			list* head = this;
			if (this->next == temp)
			{
				head->next = temp_next;
				temp_next->prev = NULL;
			}
			else if (temp->next == NULL)
			{
				head->prev = temp_prev;
				temp_prev->next = NULL;
			}
			else
			{
				temp_prev->next = temp_next;
				temp_next->prev = temp_prev;
			}
	}
};
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	list head(0);
	head.add(8);
	head.add(22);
	head.add(6);
	head.add(22);
	head.add(4);
	
	//head.show();


	head.Delete(22);

	head.show();
	//head.show();
	system("pause");
	return 0;
}
