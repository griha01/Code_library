#include <iostream>
#include <Windows.h>
#include <string>

using namespace std;

void set(double* A, int N, int& flag, int tail, int& head, double a)
{
	if (flag == -2) return;
	A[head++] = a;
	if (head == N) head = 0;
	flag=(head == tail)?-2:0;
}

void get(double* A, int N, int& flag, int& tail, int head, double& a)
{
	if (flag == -1)return;
	if (flag == -2) {
		a = A[tail++];
		if (tail == N)tail = 0;
		flag = 0;
	}
	if (flag == 0) {
		a = A[tail++];
		if (tail == N)tail = 0;
		if (tail == head) flag = -1;
	}
/*
	if (flag == -1)return;
	a = A[tail++];
	if (tail == N)tail = 0;
	flag = (tail == head) ? -1:0
	*/

}
void show(double* A, int N, int flag, int tail,int head) {
	if (flag == -1) return;
	if (flag==0)
		while (tail != head )
		{
			cout << A[tail++] << "\t";
			if (tail == N) tail = 0;
		}
	else
		do 
		{
			cout << A[tail++] << "\t";
			if (tail == N) tail = 0;
		} while (tail != head);
		cout << endl;
}
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	const int N = 6;
	double number = 0;
	int flag = 0;
	double A[N] = {88,99, -9, -10, 33, 77};
	int tail = 4, head = 2;
	show(A, N, flag, tail,head);

	double B[N] = { 88,99, -9, -10, 33, 77 };
	show(B, N, -2, 3, 3);

	double C[N] = { 88,99, -9, -10, 33, 77 };
	flag = -1;
	head = tail = 5;
	set(C, N, flag, tail, head, 10);
	show(C, N, flag, tail, head);

	get(C, N, flag, tail, head, number);
	show(C, N, flag, tail, head);
	cout << "Number:" << number << endl;
	/*cout << endl <<set(A,N, tail, head,10) << endl;
	cout << endl;
	show(A, tail, head, N);
	cout << endl << get(A, N, tail, head, number) << endl;
	cout << endl;
	show(A, tail, head, N);
	cout << endl;*/
	system("pause");
}
