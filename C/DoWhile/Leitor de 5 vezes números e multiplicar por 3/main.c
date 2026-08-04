#include <stdio.h>

int main()
{
    int num = 0, muliplicador = 0, cont = 1;
    
    do{
        
        printf("Digite um número inteiro: ");
        scanf("%d", &num);
        
        muliplicador = num * 3;
        
        
        printf("\n%d x 3 = %d",num, muliplicador);
        
        cont++;
        
        printf("\n\n");
    }
    
    while (cont <= 5);

    return 0;
}
