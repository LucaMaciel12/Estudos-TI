#include <stdio.h>

int main()
{
    int  num, cont =1, tabuada=0;
    
    printf ("Digite um número para o cálculo da tabuada: ");
    scanf("%d",&num);
    

    while (cont <= 10){
        tabuada = num * cont;
        printf("\n%d x %d = %d\n", num, cont, tabuada);
        cont++;
        
    }


    return 0;
}
