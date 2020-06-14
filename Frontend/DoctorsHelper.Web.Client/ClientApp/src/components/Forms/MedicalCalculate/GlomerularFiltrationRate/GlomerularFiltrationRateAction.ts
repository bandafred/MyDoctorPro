import {
    GlomerularFiltrationRateResponse,
    GlomerularFiltrationRateClient
} from "../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../common/Interfaces';
import {getAuthClient} from "../../../../apiClient/getAuthClient";


export async function GlomerularFiltrationRateResult(
    creatinin: number | undefined,
    age: number | undefined,
    weight: number | undefined,
    height: number | undefined,
    isMen: boolean | undefined) {
    
    let res: IResult<GlomerularFiltrationRateResponse> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new GlomerularFiltrationRateClient(getAuthClient());
        res.result = await client.calculateGlomerularFiltrationRate(creatinin, age, weight, height, isMen);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}