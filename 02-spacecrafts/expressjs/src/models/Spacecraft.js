import input from "../utils/inputProvider.js"
import Random from "../utils/Random.js"
import { arrayUndef } from "../utils/utils.js" 

class Spacecraft
{
    constructor ({ manufacturer, manufactureYear, 
                category, cargo, guns, missiles, 
                thrusters, agility } = options) 
    {
        this.id = ++Spacecraft.__id
        this.manufacturer = manufacturer || "unknown"
        this.manufactureYear = manufactureYear || 2000
        this.category = category || "unknown"
        this.cargo = cargo
        this.guns = guns
        this.missiles = missiles
        this.thrusters = thrusters
        this.agility = agility
    }

    static __id = 0

    static factory (count) {
        return arrayUndef(count).map(_ => {
            const category = Random.choice(input.categories)
            let params = { 
                manufacturer: Random.choice(input.manufacturerNames),
                manufactureYear: Random.randInt(input.manufactureYears.min, input.manufactureYears.max),
                category: category.name
            }
            for (const key of ["Cargo", "Guns", "Missiles", "Thrusters", "Agility"]) {
                params[key.toLowerCase()] = Random.randInt(category["min"+key], category["max"+key])
            }
            return new Spacecraft(params)
        })
    }
}

export default Spacecraft
