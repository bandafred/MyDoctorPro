import {HASBLEDResponse, HASBLEDClient} from "../../../../apiClient/apiClient";
import {IResult} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";


export async function HASBLEDResult(
    hypertension: boolean,
    creatinineIncreased: boolean,
    transaminase: boolean,
    insult: boolean,
    bleeding: boolean,
    mno: boolean,
    oldAge: boolean,
    antiplateletAgents: boolean,
    alcohol: boolean) {
    
    let res: IResult<HASBLEDResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new HASBLEDClient(getAuthClient());
        res.result = await client.calculateHASBLED(hypertension, creatinineIncreased, transaminase, insult, bleeding, mno, oldAge, antiplateletAgents, alcohol);
    } catch (error) {
        res = {
            result: undefined,
            error: {
                errors: ["Непредвиденная ошибка"]
            },
        };
        return res;
    }

    return res;
}