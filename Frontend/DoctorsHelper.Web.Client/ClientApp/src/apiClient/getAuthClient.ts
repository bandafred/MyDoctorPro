import {AccessTokenAuthClient, AuthClient} from "../apiClient/apiClient";
import {baseUrl} from "../apiClient/baseUrl";

export const getAuthClient = () => {
    let token = localStorage.getItem("apiToken");
    return token ? new AccessTokenAuthClient(baseUrl, token) : new AuthClient(baseUrl);
}