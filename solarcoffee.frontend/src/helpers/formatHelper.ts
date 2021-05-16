const formatHelper = {
    price(input: number): string{
        if(isNaN(input)){
            return "-";
        }
        return '$' + input.toFixed(2); //Precision of 2 digits like 2.00 for input of 2 
    }
}

export default formatHelper;