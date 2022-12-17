import express from "express"
import global from "./utils/globalProvider.js"
import Spacecraft from "./models/Spacecraft.js"

import spacecraftsTxtRouter from "./routes/spacecrafts.txt.js"
import spacecraftsJsonRouter from "./routes/spacecrafts.json.js"

global.spacecrafts = Spacecraft.factory(40)

let app = express()

app.use((request, response, next) => {
    console.log(`[${new Date().toLocaleString("se")}] ${request.method} ${request.path}`)
    next();
})

app.use("/spacecrafts.txt", spacecraftsTxtRouter)
app.use("/spacecrafts.json", spacecraftsJsonRouter)

const PORT = 4000

function start () {
    setInterval(()=> {
        console.log(`[${new Date().toLocaleString("se")}] --- Keep-alive check...`)
    }, 60000)

    app.listen(PORT, () => {
        console.log(`Hmm, app is listening on port ${PORT}...`)
    })
}


export default { start }

