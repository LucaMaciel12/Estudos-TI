#include <stdio.h>

int main()
{
    int cont, idade,maior=0;
    
    for(cont = 1; cont <= 5; cont++){
        printf("Digite a idade: ");
        scanf("%d", &idade);
        
        if(idade >= 18){
        maior++;
    }
    }
    printf("%d são maiores de idade.", maior);
    
    

    return 0;
}
