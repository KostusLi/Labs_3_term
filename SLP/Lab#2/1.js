//#1
function basicOperation(operation, value1, value2) {
    
    if(operation=='+')
    {
        return value1+value2;
    }
    else if(operation=='-')
    {
        return value1-value2;
    }
    else if(operation=='*')
    {
        return value1*value2;
    }
    else if(operation=='/'){
        return value1/value2;
    }
}

let result = basicOperation('+', 5, 10);
console.log(result);



//#2
function powThird(n)
{
    let result=0;
    for(let i=1; i<=n; i++)
    {
        result+=i**3;
    }
    return result;
}

console.log(powThird(3));


//#3
function average(arr){
    let sum=0, count=0;
    for(let i=0; i<arr.length; i++)
    {
        sum+=arr[i];
        count++;
    }
    return sum/count;
}

let arr= [1, 2, 3, 4, 5];
console.log(average(arr));


//#4
function reverseStr(str)
{
    let res="";
    let reg = /[А-Яа-яёЁ]/;
    for(let i=str.length-1; i>=0; i--)
    {
        if(checking(str[i], reg))
        {
            res+=str[i];
        }
    }
    return res;
}

const checking = (str, reg) => {
    return reg.test(str);
}

let str = "JavaScr53э? ipt";
console.log(reverseStr(str));


//#5
function repeatString(n, s){
    let temp=s;
    while(n-1)
    {
        s+=temp;
        n--;
    }
    return s;
}

let str1 = "Hello";
let n=5;
console.log(repeatString(n, str1));


//#6
function exclusiveStroke(arr1, arr2){
    let arr3=[]
    for(let i=0; i<arr1.length; i++)
    {
        let check = true;

        for(let j=0; j<arr.length; j++)
        {
            if(arr1[i]==arr2[j])
            {
                check=false;
            }
        }

        if(check)
        {
            arr3.push(arr1[i]);
        }
    }
    return arr3;        
}

let arr1=["errkjh", "rec", "gth", "thul.k"];
let arr2 = ["fbd,kj", "rec", "gth", "dcsbg"];
console.log(exclusiveStroke(arr1, arr2));