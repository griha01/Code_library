#include <iostream>
#include <Windows.h>
#include <string>

using namespace std;

bool get(double* A, int size,int &tail,int head,double a)
{
	if (head == 0 && tail == 0) return false;

}
bool set(double* A, int size, int& tail, int head, double a)
{

}
void show(double* A,int size) {
	for (int i = 0; i < size; i++)
	{
		cout << A << " " << endl;
	}
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	const int N = 10;
	double A[N] = {33,77,88};
	show(A, N);
	int tail = 0, head = 3;
	system("pause");
}
