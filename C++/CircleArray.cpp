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
	return true;
}
void show(double* A,int tail,int head,int N) {
	while (tail != head )
	{
		cout << A[tail++] << " " << endl;
		if (tail == N) tail = 0;
	}
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	const int N = 6;
	double A[N] = {88,99, -9, -10, 33, 77};
	int tail = 4, head = 2;
	show(A, tail, head, N);
	system("pause");
}
