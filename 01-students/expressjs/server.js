import express from "express"
import global from "./lib/global.js"
import Student from "./lib/Student.js"

import studentsJsonRouter from "./routes/students-json.js"
import studentsTxtRouter from "./routes/students-txt.js"

global.students = Student.factory(40)

let app = express()

app.use((request, response, next) => {
    console.log(`[${new Date().toLocaleString("se")}] ${request.method} ${request.path}`)
    next();
})

app.use("/students.json", studentsJsonRouter)
app.use("/students.txt", studentsTxtRouter)

setInterval(()=> {
    console.log(`[${new Date().toLocaleString("se")}] --- Keep-alive check...`)
}, 60000)

const PORT = 4000
app.listen(PORT, () => {
    console.log(`Hmm, app is listening on port ${PORT}...`)
})
