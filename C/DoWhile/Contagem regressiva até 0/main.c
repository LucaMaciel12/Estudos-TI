#include <stdio.h>

int main()
{
    int num;
    
    printf("Digite um número: ");
    scanf("%d", &num);
    
    do{
        printf("%d ", num);
        num--;
    }
    
    while(num >= 0);
    
    return 0;
}
