import express from "express"
import global from "../lib/global.js"

const students = () => global.students

let stringifyStudent = (s, key) => (key != undefined? `- key: ${key}\n`:``)+
    `  surname: ${s.surname} \n  name: ${s.name} \n`+
    `  course: ${s.course} \n  group: ${s.group} \n`+
    `  points: ${s.points.join(", ")}\n` 

let router = express.Router()

router.get("\/?(index)?", (request, response) => {
    response.status(200)
    .header("Content-Type", "text/plain")
    .send(students().map((s, key) => stringifyStudent(s, key)).join("\n"))
})

router.get("/course/:course", (request, response) => {
    let course = Number.parseInt(request.params["course"])
    let selection = students().map((s, key) => [s, key])
        .filter(([s, key]) => s.course == course)
    if (selection.length > 0) {
        response.status(200)
        .header("Content-Type", "text/plain")
        .send(selection.map(([s, key]) => stringifyStudent(s, key)).join("\n"))
    }
    else {
        response.status(404)
        .header("Content-Type", "text/plain")
        .send(`Course ${course} wasn't found`)
    }
})

router.get("/group/:group", (request, response) => {
    let group = request.params["group"]
    let selection = students().map((s, key) => [s, key])
        .filter(([s, key]) => s.group == group)
    if (selection.length > 0) {
        response.status(200)
        .header("Content-Type", "text/plain")
        .send(selection.map(([s, key]) => stringifyStudent(s, key)).join("\n"))
    }
    else {
        response.status(404)
        .header("Content-Type", "text/plain")
        .send(`Group ${group} wasn't found`)
    }
})

router.get("/:id([0-9]+)", (request, response) => {
    let id = Number.parseInt(request.params["id"])
    let student = students()[id]
    if (student) {
        response.status(200)
        .header("Content-Type", "text/plain")
        .send(stringifyStudent(student, id))
    }
    else {
        response.status(404)
        .header("Content-Type", "text/plain")
        .send(`Student with id=${id} wasn't found`)
    }
})

export default router
