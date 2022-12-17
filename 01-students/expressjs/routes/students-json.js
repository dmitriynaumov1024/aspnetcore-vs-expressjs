import express from "express"
import global from "../lib/global.js"

const students = () => global.students

let router = express.Router()

router.get("\/?(index)?", (request, response) => {
    response.status(200)
    .json(students())
})

router.get("/course/:course", (request, response) => {
    let course = Number.parseInt(request.params["course"])
    let selection = students().map((s, key) => [s, key])
        .filter(([s, key]) => s.course == course)
    if (selection.length > 0) {
        response.status(200)
        .json(selection.map(([s, key]) => s))
    }
    else {
        response.status(404)
        .json({ message: `Course ${course} wasn't found` })
    }
})

router.get("/group/:group", (request, response) => {
    let group = request.params["group"]
    let selection = students().map((s, key) => [s, key])
        .filter(([s, key]) => s.group == group)
    if (selection.length > 0) {
        response.status(200)
        .json(selection.map(([s, key]) => s))
    }
    else {
        response.status(404)
        .json({ message: `Group ${group} wasn't found` })
    }
})

router.get("/:id([0-9]+)", (request, response) => {
    let id = Number.parseInt(request.params["id"])
    let student = students()[id]
    if (student) {
        response.status(200)
        .json(student)
    }
    else {
        response.status(404)
        .json({ message: `Student with id=${id} wasn't found` })
    }
})

export default router
