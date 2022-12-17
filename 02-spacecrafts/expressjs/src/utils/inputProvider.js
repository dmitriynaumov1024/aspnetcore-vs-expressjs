import { readFileSync } from "node:fs"
export default JSON.parse(readFileSync("../science/input.json"))
