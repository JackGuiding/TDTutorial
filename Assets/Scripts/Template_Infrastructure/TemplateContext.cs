using System;
using System.Collections.Generic;
using UnityEngine;

public class TemplateContext {

    public Dictionary<int, RoleTM> roles;
    public Dictionary<int, TowerTM> towers;

    public TemplateContext() {
        roles = new Dictionary<int, RoleTM>();
        towers = new Dictionary<int, TowerTM>();
    }

} 