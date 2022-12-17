import express from "express"
import global from "../utils/globalProvider.js"

const spacecrafts = () => global.spacecrafts

const stringifySpacecraft = (s) => 
    `- id: ${s.id}\n` + 
    Object.entries(s)
    .filter(([key, value]) => key!="id")
    .map(([key, value]) => `  ${key}: ${value}\n`)
    .join("")

let router = express.Router()

router.get("\/?(index)?", (request, response) => {
    response.status(200).type("text/plain")
    .send(spacecrafts().map(stringifySpacecraft).join("\n\n"))
})

router.get("/category/:category", (request, response) => {
    const category = request.params.category.toLowerCase()
    let selection = spacecrafts().filter(s => s.category.toLowerCase() == category)
    if (selection.length) {
        response.status(200).type("text/plain")
        .send(selection.map(stringifySpacecraft).join("\n\n"))
    }
    else {
        response.status(404).type("text/plain")
        .send(`Category ${category} does not exist.`)
    }
})

router.get("/manufacturer/:manufacturer", (request, response) => {
    const manufacturer = request.params.manufacturer.toLowerCase()
    let selection = spacecrafts().filter(s => s.manufacturer.toLowerCase() == manufacturer)
    if (selection.length) {
        response.status(200).type("text/plain")
        .send(selection.map(stringifySpacecraft).join("\n\n"))
    }
    else {
        response.status(404).type("text/plain")
        .send(`Manufacturer ${manufacturer} does not exist.`)
    }
})

router.get("/:id([0-9]{1,3})", (request, response) => {
    const id = request.params.id
    let spacecraft = spacecrafts().find(s => s.id == id) 
    if (spacecraft) {
        response.status(200).type("text/plain")
        .send(stringifySpacecraft(spacecraft))
    } 
    else {
        response.status(404).type("text/plain")
        .send(`Spacecraft with id=${id} was not found.`)
    }
})

export default router
