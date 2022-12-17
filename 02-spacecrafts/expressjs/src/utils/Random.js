class Random 
{
    static randInt (minval, maxval) {
        return (Math.random()*(maxval-minval) + minval) | 0 
    }

    static choice (array) {
        return array[this.randInt(0, array.length)]
    }
}

export default Random;
