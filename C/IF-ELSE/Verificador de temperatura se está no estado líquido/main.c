#include <stdio.h>

int main()
{
    float temperatura;
    
    printf("Digite a temperatura em graus celsius: ");
    scanf("%f", &temperatura);
    
    if(temperatura > 0 || temperatura < 100){
     printf("\nA temperatura está no estado líquido") ;  
    }
    else{
     printf("\nA temperatura não está no estado líquido");
    }
    return 0;
}
