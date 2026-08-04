#include <stdio.h>

int main()
{   
    float valor1 = 80;
    int ano = 1;
    
    while(valor1 <= 5000){
    ano++;    
    valor1 = valor1 * 2;
    }
    
    printf("A prestação irá demorar %d anos para ficar maior que R$ 5000,00", ano);
    
    return 0;
}                       
