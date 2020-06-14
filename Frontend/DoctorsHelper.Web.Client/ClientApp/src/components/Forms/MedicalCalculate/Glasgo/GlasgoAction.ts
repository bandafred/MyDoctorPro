import {GlasgoResponse, GlasgoClient} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";


export async function GlasgoResult(eyeResponse: number, verbalResponse: number, motorResponse: number) {
    let res: IResult<GlasgoResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new GlasgoClient(getAuthClient());
        res.result = await client.calculateGlasgo(eyeResponse, verbalResponse, motorResponse);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}