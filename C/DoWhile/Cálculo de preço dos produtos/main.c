#include <stdio.h>

int main()
{
    float preco_produto, acumulador = 0;
    
    do{
        printf("Digite o preço do do produto (Caso não tenha mais produtos , digite 0): R$ ");
        scanf("%f", &preco_produto);
        
        acumulador = acumulador + preco_produto;
        
    }
    
    while(preco_produto != 0);
    
    printf("\nO valor total dos produtos é: R$ %0.2f", acumulador);

    return 0;
}
