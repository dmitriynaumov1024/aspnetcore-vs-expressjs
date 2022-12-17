import Random from "./Random.js"
import { arrayUndef } from "./utils.js"

class Student 
{
    constructor ({ surname, name, course, group, points } = options) {
        this.surname = surname
        this.name = name
        this.course = course
        this.group = group
        this.points = points
    }
    
    minPointInRange (minval, maxval=999999) {
        if (this.points.length == 0) return false
        let minpoint = Math.min(...this.points)
        return minpoint >= minval && minpoint <= maxval
    }
    
    allPointsAtLeast (minval) {
        return this.minPointInRange(minval)
    }

    canPassCred () {
        return this.allPointsAtLeast(60)
    }

    static factory (count) {
        const SURNAMES = [
            "Johnson", "Juhansson", "Marks", "Peters", "Smith", 
            "Doe", "Willis", "Evans", "Reeves", "Stevenson",
            "Parks", "Kings", "Rishi", "Morinho", "Castillo"
        ]
        const NAMES = [
            "John", "Yana", "Steve", "Francis", "Liam",
            "Hanna", "Liss", "Kate", "Joseph", "Eva",
            "Rina", "Michael", "Antonio", "Leonard", "Benedict",
            "Thomas", "Mark", "Alexander", "Alexandra", "Susan"
        ]
        const COURSES_GROUPS = [
            [1, "8621-a"],
            [1, "8621-b"],
            [2, "8622-a"],
            [2, "8622-b"],
            [3, "8623-a"],
            [3, "8623-b"]
        ]
        const POINTS = [
            35, 43, 53, 59, 61, 63, 65, 67, 70, 71,
            72, 72, 73, 73, 74, 74, 75, 75, 76, 76,
            77, 77, 79, 81, 83, 84, 86, 88, 90, 92,
        ]

        return arrayUndef(count)
        .map(_ => [
            Random.choice(POINTS), 
            ...Random.choice(COURSES_GROUPS)
        ])
        .map(([minpoint, course, group]) => new Student ({
            surname: Random.choice(SURNAMES),
            name: Random.choice(NAMES),
            course: course,
            group: group,
            points: arrayUndef(Random.randInt(6, 10))
                .map(_ => Random.randInt(minpoint, 100))
        }))
    }
}

export default Student;
