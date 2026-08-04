#include <stdio.h>

int main()
{
    int n, cont=1;
    
    printf("Digite um número: ");
    scanf("%d", &n);
    
    while(cont <= n){
        
        if(cont % 2 == 0){
        
        printf("\n%d", cont);
        
        }
        cont++;
    }
    
    return 0;
}
