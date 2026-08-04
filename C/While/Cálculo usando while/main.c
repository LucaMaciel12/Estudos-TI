#include <stdio.h>

int main()
{
    int num, soma =0;
    
    while(num != 0){
    
    printf("\nDigite um número inteiro para soma (ou digite 0 para parar): ");
    scanf("%d", &num);
        
    soma = soma + num;
    
    }
    
    printf ("\nA soma de todos os números é %d", soma);

    return 0;
}
