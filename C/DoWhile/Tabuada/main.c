#include <stdio.h>

int main()
{
    int  num, cont =0, tabuada=0, opcao;
    
    do{
        
    printf ("Digite um número para o cálculo da tabuada: ");
    scanf("%d",&num);
    
    

    while (cont <= 10){
        tabuada = num * cont;
        printf("\n%d x %d = %d\n", num, cont, tabuada);
        cont++;
    }
    
    printf("Digite 1 para continuar ou 0 para encerrar: ");
    scanf("%d", &opcao);
    }
        while(opcao == 1);
    
    return 0;
}
