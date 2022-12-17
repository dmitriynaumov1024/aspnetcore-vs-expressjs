function isArrow(callback) {
    return callback.constructor == Function 
        && callback.prototype == undefined
}

function tryAndCatch(callback) {
    try {
        callback()
    }
    catch (e) {
        console.error(e)
    }
}

function arrayZeros(size) {
    return Array(size).fill(0)
}

function arrayUndef(size) {
    return Array(size).fill(undefined)
}

export {
    isArrow,
    tryAndCatch,
    arrayZeros,
    arrayUndef
}
